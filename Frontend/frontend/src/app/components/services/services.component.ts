import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../UserModel';

@Component({
  selector: 'app-services',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})

export class ServicesComponent implements OnInit {
  users: UserModel[] = [];
  selectedUser: UserModel | null = null;
  newUser: UserModel = { id: '', name: '', mail: '' };
  showCreateDialog: boolean = false;
  showEditDialog: boolean = false;
  searchId: string = '';

  constructor(private userService: UserService, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.fetchUsers();
  }

  fetchUsers() {
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = data || [];   
      },
      error: (err) => {
        alert(`Failed to fetch user, Error: ${err.message}`);
      },
    });
  }

  searchUserById() {
    const searchId = this.searchId.trim();
    if (searchId) {
      this.userService.getUser(searchId).subscribe({
        next: (user: UserModel[] | string) => {
          if (typeof user === "string") {
            console.error(user);
            alert(user);
            return;
          }
      
          if (Array.isArray(user)) {
            this.users = user;
          } else {
            this.users = [user]; 
          }
        },
        error: (err: Error) => {
          alert(`Failed to fetch user, Error: ${err.message}`);
        },
      });
    } else {
      this.userService.getUsers().subscribe({
        next: (allUsers: UserModel[]) => {
          this.users = allUsers;
        },
        error: (err: Error) => {
          alert(`Failed to fetch all users, Error: ${err.message}`);
        },
      });
    }
  }
  
  openCreateDialog() {
    this.closeDialog(); 
    this.showCreateDialog = true;
    this.newUser = { id: '', name: '', mail: '' };
  }

  openEditDialog(user: any) {
    this.closeDialog();
    this.showEditDialog = true;
    this.selectedUser = { ...user }; 
  }

  closeDialog() {
    this.showCreateDialog = false;
    this.showEditDialog = false;
    this.selectedUser = null;
  }

  saveNewUser() {
    if (this.newUser.name.trim() && this.newUser.mail.trim()) {
      this.userService.addUser(this.newUser).subscribe({
        next: (createdUser) => {
          this.fetchUsers();
          alert('User created successfully');
          
          this.users.push(createdUser);
  
          this.closeDialog();
        },
        error: (err) => {
          alert(`Error creating user, Error: ${err.message}`);
        },
      });
    } else {
      alert('Please fill in all fields');
    }
  }
  
  saveEditedUser() {
    if (this.selectedUser && this.selectedUser.name.trim() && this.selectedUser.mail.trim()) {
      this.userService.updateUser(this.selectedUser).subscribe({
        next: () => {
          alert('User updated successfully');
          this.fetchUsers(); 
          this.closeDialog();
        },
        error: (err) => {
          alert(`Error updating user, Error: ${err.message}`);
        },
      });
    } else {
      alert('Please fill in all fields');
    }
  }

  deleteUser(id: string): void {
    if (!id) {
      alert('User ID is required to delete');
      return;
    }
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(id).subscribe({
        next: () => {
          alert('User deleted successfully');
          this.fetchUsers(); 
        },
        error: (err) => {
          console.error(`Error deleting user, Error: ${err.message}`);
          alert('Failed to delete user');
        },
      });
    }
  }
}
