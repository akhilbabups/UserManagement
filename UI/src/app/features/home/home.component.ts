import { Component, OnInit } from '@angular/core';
import { UserdataService } from 'src/app/services/userdata.service';
import { User } from '../models';

@Component({
  selector: 'users-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  users!: User[];
  isAdding: boolean = false;
  isEditing: boolean = false;

  constructor(private service: UserdataService) { }

  ngOnInit(): void {
    this.service.getUsers()
    .subscribe(response=>{
      this.users = response;      
    });
  }

  addClick(){
    this.isAdding = true;
  }

  updateUser(user:User){

  }

  submit(fm:any){
    console.log(JSON.stringify(fm.value));

    this.service.addUser(fm.value)
    .subscribe(resp=>{
      this.users.push(resp);
      this.isAdding = false;
    });
  }
}
