import { Component, inject } from '@angular/core';
import { ResultService } from '../result.service';
import { Result } from '../../../core/models/Result';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-result-list',
  templateUrl: './result-list.component.html',
  imports: [RouterLink,CommonModule],
  styleUrls: ['./result-list.component.scss'],
  standalone: true,
})
export class ResultListComponent {
  results: Result[] = [];
  private resultService = inject(ResultService);

  constructor() {
    this.resultService.getResults().subscribe((data) => (this.results = data));
  }
}
