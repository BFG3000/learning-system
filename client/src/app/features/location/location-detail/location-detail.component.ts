import { Component, inject } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { LocationService } from '../location.service';
import { Location } from '../../../core/models/Location';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-location-detail',
  imports: [RouterLink,CommonModule],
  templateUrl: './location-detail.component.html',
  styleUrl: './location-detail.component.scss'
})
export class LocationDetailComponent {
  location: Location | null = null;
  private route = inject(ActivatedRoute);
  private locationService = inject(LocationService);

  constructor() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.locationService.getLocationById(id).subscribe((data) => (this.location = data));
  }
}
