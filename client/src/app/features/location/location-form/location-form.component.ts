import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LocationService } from '../location.service';
import { Location } from '../../../core/models/Location';

@Component({
  selector: 'app-location-form',
  templateUrl: './location-form.component.html',
  styleUrls: ['./location-form.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule], // Import Reactive Forms
})
export class LocationFormComponent {
  locationForm: FormGroup;
  isEditMode = false;
  private locationService = inject(LocationService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.locationForm = this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zipCode: ['', Validators.required],
    });

    const locationId = this.route.snapshot.paramMap.get('id');
    if (locationId) {
      this.isEditMode = true;
      this.locationService.getLocationById(+locationId).subscribe((location: Location) => {
        this.locationForm.patchValue(location);
      });
    }
  }

  onSubmit(): void {
    if (this.locationForm.invalid) return;

    const formData = this.locationForm.value;
    if (this.isEditMode) {
      this.locationService.updateLocation(formData).subscribe(() => {
        alert('Location updated successfully');
        this.router.navigate(['/location']);
      });
    } else {
      this.locationService.createLocation(formData).subscribe(() => {
        alert('Location created successfully');
        this.router.navigate(['/location']);
      });
    }
  }
}
