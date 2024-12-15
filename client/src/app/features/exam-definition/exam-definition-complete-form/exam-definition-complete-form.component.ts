import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStep, MatStepperModule } from '@angular/material/stepper';
import { ExamDefinition } from '../../../core/models/ExamDefinition';
import { ExamDefinitionService } from '../exam-definition.service';
import { ActivatedRoute } from '@angular/router';
import { ExamVariant } from '../../../core/models/ExamVariant';
import { Exam } from '../../../core/models/Exam';
import { Location } from '../../../core/models/Location';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ToastService } from '../../../shared/component/toast/toast.service';
import { ExamType } from '../../../core/models/ExamType';
import { Category } from '../../../core/models/Category';
import { ExamTypeService } from '../../exam-type/exam-type.service';
import { CategoryService } from '../../category/category.service';
import { MatOption, MatSelect } from '@angular/material/select';
import { LocationService } from '../../location/location.service';
import { MatTable } from '@angular/material/table';
import { MatDivider } from '@angular/material/divider';

@Component({
  selector: 'app-exam-definition-complete-form',
  imports: [CommonModule,
    // MatLabel,
    // MatFormField,
    // MatStep,
    // MatTable,
    // MatSelect,
    // MatOption,
    // MatDivider,
    ReactiveFormsModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    // BrowserAnimationsModule,
  ],
  templateUrl: './exam-definition-complete-form.component.html',
  styleUrl: './exam-definition-complete-form.component.scss'
})
export class ExamDefinitionCompleteFormComponent {
  examTypes: ExamType[] = [];
  categories: Category[] = [];
  locations: Location[] = [];
  examDefinitionForm: FormGroup;
  examVariantForm: FormGroup;
  examForm: FormGroup;
  questionForm : FormGroup;

  isEditMode = false;
  correctNum:any;

  stepperIndex = 0;
  startAdd:boolean = false
  examsComplete:boolean = false
  preview:boolean = false

  examDefinitionService = inject(ExamDefinitionService)
  private _toast = inject(ToastService);
  private examTypeService = inject(ExamTypeService);
  private categoryService = inject(CategoryService);
  private locationService = inject(LocationService);
  private route = inject(ActivatedRoute);

  constructor(private fb: FormBuilder) {
    this.locationService
      .getLocations()
      .subscribe((data) => (this.locations = data));

    this.examTypeService.getExamTypes().subscribe((data) => {
      this.examTypes = data;
    });

    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;
    });

    this.examDefinitionForm = this.fb.group({
      name: ['', Validators.required],
      categoryId: [null, Validators.required],
      duration: [0, [Validators.required, Validators.min(1)]],
      examTypeId: [null, Validators.required],
      examVariants: this.fb.array([]),
      exams: this.fb.array([]),
    });

    this.examVariantForm = this.fb.group({
      name: ['', Validators.required],
      examDefinitionId: [null],
    });

    this.examForm = this.fb.group({
      name: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      locationId: [null, Validators.required],
    });

    this.questionForm = this.fb.group({
      name: ['', Validators.required],
      marks: ['', [Validators.required, Validators.min(1)]],
    });
    
    const examDefinitionId = this.route.snapshot.paramMap.get('id');
    if (examDefinitionId) {
      this.isEditMode = true;
      this.examDefinitionService.getExamDefinitionById(+examDefinitionId).subscribe((examDefinition: ExamDefinition) => {
        
        this.examDefinitionForm.patchValue(examDefinition);
      });
    }
    
  }

  start() {
    if(this.examDefinitionForm.get('name')?.invalid) {
      this._toast.openSnackBar('Please Enter The Exam Group','danger')
    }else {
      this.startAdd = true
    }

    if(this.startAdd) {
      this.stepperIndex = 1
    }
  }

  addVariant() {
    const variantGroup = this.fb.group({
      variantName: ['', Validators.required],
      questions: this.fb.array([]),
    });
   // this.examVariants.push(variantGroup);
  }

  // getQuestions(variantIndex: number): FormArray {
  //   //return this.examVariants.at(variantIndex).get('questions') as FormArray;
  // }

  // addAnswer(variantIndex: number, questionIndex: number) {
  //   const answersArray = this.getAnswers(variantIndex, questionIndex);
  //   const answerGroup = this.fb.group({
  //     name: ['', Validators.required],
  //     isCorrect: [false],
  //   });
  //   answersArray.push(answerGroup);
  // }

  // getAnswers(variantIndex: number, questionIndex: number): FormArray {
  //   return this.getQuestions(variantIndex).at(questionIndex).get('answers') as FormArray;
  // }

  get examsArray(): FormArray {
    return this.examDefinitionForm.get('exams') as FormArray;
  }
}
