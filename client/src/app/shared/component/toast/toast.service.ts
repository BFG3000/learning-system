import { inject, Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

type AlertType = 'info' | 'success' | 'danger';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  private _snackBar = inject(MatSnackBar);

  private horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  private verticalPosition: MatSnackBarVerticalPosition = 'bottom';

  private getBootstrapClass(alertType: AlertType): string {
    switch (alertType) {
      case 'info':
        return 'bg-info'; 
      case 'success':
        return 'bg-success';
      case 'danger':
        return 'bg-danger'; 
      default:
        return ''; 
    }
  }


  openSnackBar(message:string,type :AlertType) {
    this._snackBar.open(message, 'Close', {
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
      duration: 4000,
      panelClass : this.getBootstrapClass(type)
    });
  }
}
