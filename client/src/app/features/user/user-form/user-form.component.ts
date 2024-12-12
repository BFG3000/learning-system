import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { User } from '../../../core/models/User';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule], // Import reactive forms module
})
export class UserFormComponent {
  userForm: FormGroup;
  isEditMode = false;
  private userService = inject(UserService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
    });

    const userId = this.route.snapshot.paramMap.get('id');
    if (userId) {
      this.isEditMode = true;
      this.userService.getUserById(+userId).subscribe((user: User) => {
        this.userForm.patchValue(user);
      });
    }
  }

  onSubmit(): void {
    if (this.userForm.invalid) return;

    const formData = this.userForm.value;
    if (this.isEditMode) {
      this.userService.updateUser(formData).subscribe(() => {
        alert('User updated successfully');
        this.router.navigate(['/user']);
      });
    } else {
      this.userService.createUser(formData).subscribe(() => {
        alert('User created successfully');
        this.router.navigate(['/user']);
      });
    }
  }
}
