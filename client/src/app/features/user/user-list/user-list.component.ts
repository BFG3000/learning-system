import { Component, inject } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../../../core/models/User';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  imports: [RouterLink,CommonModule],
  standalone: true,
})
export class UserListComponent {
  users: User[] = [];
  private userService = inject(UserService);

  constructor() {
    this.userService.getUsers().subscribe((data) => (this.users = data));
  }
}
