import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../user.service';
import { User } from '../../../core/models/User';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  imports: [CommonModule],
  styleUrls: ['./user-detail.component.scss'],
  standalone: true,
})
export class UserDetailComponent {
  user: User | null = null;
  private route = inject(ActivatedRoute);
  private userService = inject(UserService);

  constructor() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.userService.getUserById(id).subscribe((data) => (this.user = data));
  }
}
