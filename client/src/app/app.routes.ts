import { Routes } from '@angular/router';
import { authGuard } from './auth/auth.guard';

// Import standalone components directly
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { LoginComponent } from './auth/login/login.component';
import { ExamListComponent } from './features/exam/exam-list/exam-list.component';
import { ExamDetailComponent } from './features/exam/exam-detail/exam-detail.component';
import { ExamFormComponent } from './features/exam/exam-form/exam-form.component';
import { QuestionListComponent } from './features/question/question-list/question-list.component';
import { QuestionDetailComponent } from './features/question/question-detail/question-detail.component';
import { ResultListComponent } from './features/result/result-list/result-list.component';
import { ResultDetailComponent } from './features/result/result-detail/result-detail.component';
import { UserListComponent } from './features/user/user-list/user-list.component';
import { UserDetailComponent } from './features/user/user-detail/user-detail.component';
import { QuestionFormComponent } from './features/question/question-form/question-form.component';
import { ResultFormComponent } from './features/result/result-form/result-form.component';
import { UserFormComponent } from './features/user/user-form/user-form.component';
import { LocationListComponent } from './features/location/location-list/location-list.component';
import { LocationDetailComponent } from './features/location/location-detail/location-detail.component';
import { LocationFormComponent } from './features/location/location-form/location-form.component';
import { ExamVariantFormComponent } from './features/exam-variant/exam-variant-form/exam-variant-form.component';
import { ExamVariantDetailComponent } from './features/exam-variant/exam-variant-detail/exam-variant-detail.component';
import { ExamVariantListComponent } from './features/exam-variant/exam-variant-list/exam-variant-list.component';
import { ExamDefinitionFormComponent } from './features/exam-definition/exam-definition-form/exam-definition-form.component';
import { ExamDefinitionDetailComponent } from './features/exam-definition/exam-definition-detail/exam-definition-detail.component';
import { ExamDefinitionListComponent } from './features/exam-definition/exam-definition-list/exam-definition-list.component';
import { ExamQuestionFormComponent } from './features/exam-question/exam-question-form/exam-question-form.component';

// Define routes
export const routes: Routes = [
  { path: 'login', component: LoginComponent },

  {
    path: '',
    component: DashboardComponent,
    canActivate: [authGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'exam', component: ExamListComponent },
      { path: 'exam/:id', component: ExamDetailComponent },
      { path: 'exam/form', component: ExamFormComponent },
      { path: 'question', component: QuestionListComponent },
      { path: 'question/:id', component: QuestionDetailComponent },
      { path: 'question/form', component: QuestionFormComponent },
      { path: 'result', component: ResultListComponent },
      { path: 'result/:userExamId', component: ResultDetailComponent },
      { path: 'result/form', component: ResultFormComponent },
      { path: 'user', component: UserListComponent },
      { path: 'user/:id', component: UserDetailComponent },
      { path: 'user/form', component: UserFormComponent },
      { path: 'location', component: LocationListComponent },
      { path: 'location/:id', component: LocationDetailComponent },
      { path: 'location/form', component: LocationFormComponent },
      { path: 'exam-definition', component: ExamDefinitionListComponent },
      { path: 'exam-definition/:id', component: ExamDefinitionDetailComponent },
      { path: 'exam-definition/form', component: ExamDefinitionFormComponent },
      { path: 'exam-variant', component: ExamVariantListComponent },
      { path: 'exam-variant/:id', component: ExamVariantDetailComponent },
      { path: 'exam-variant/form', component: ExamVariantFormComponent },
      // { path: 'exam-question', component: ExamQuestionListComponentnt },
      { path: 'exam-question/form', component: ExamQuestionFormComponent },
    ],
  },

  // Redirect to login for undefined paths
  { path: '**', redirectTo: 'login' },
];
