import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExamDefinitionService } from '../exam-definition.service';
import { ExamDefinition } from '../../../core/models/ExamDefinition';
import {RouterModule} from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-exam-definition-detail',
  templateUrl: './exam-definition-detail.component.html',
  styleUrls: ['./exam-definition-detail.component.scss'],
  imports:[RouterModule,CommonModule],
  standalone: true,
})
export class ExamDefinitionDetailComponent {
  examDefinition: ExamDefinition | null = null;
  private examDefinitionService = inject(ExamDefinitionService);
  private route = inject(ActivatedRoute);

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.examDefinitionService.getExamDefinitionById(id).subscribe((data) => {
      this.examDefinition = data;
    });
  }
}
