import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { LocationService } from '../location.service';
import { Location } from '../../../core/models/Location';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-location-list',
  imports: [RouterLink,CommonModule],
  templateUrl: './location-list.component.html',
  styleUrl: './location-list.component.scss',
})
export class LocationListComponent {
  locations: Location[] = [];
  private locationService = inject(LocationService);

  constructor() {
    this.locationService
      .getLocations()
      .subscribe((data) => (this.locations = data));
  }
}
