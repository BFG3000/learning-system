import { Component, inject } from '@angular/core';
import { ExamDefinitionService } from '../exam-definition.service';
import { ExamDefinition } from '../../../core/models/ExamDefinition';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-exam-definition-list',
  templateUrl: './exam-definition-list.component.html',
  imports: [RouterLink,CommonModule],
  styleUrls: ['./exam-definition-list.component.scss'],
  standalone: true,
})
export class ExamDefinitionListComponent {
  examDefinitions: ExamDefinition[] = [];
  private examDefinitionService = inject(ExamDefinitionService);

  ngOnInit(): void {
    this.examDefinitionService.getExamDefinitions().subscribe((data) => {
      this.examDefinitions = data;
    });
  }
}
