import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ResultService } from '../result.service';
import { Result } from '../../../core/models/Result';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-result-detail',
  templateUrl: './result-detail.component.html',
  imports: [CommonModule],
  styleUrls: ['./result-detail.component.scss'],
  standalone: true,
})
export class ResultDetailComponent {
  result: Result | null = null;
  private route = inject(ActivatedRoute);
  private resultService = inject(ResultService);

  constructor() {
    const id = Number(this.route.snapshot.paramMap.get('userExamId'));
    this.resultService.getResultById(id).subscribe((data) => (this.result = data));
  }
}
