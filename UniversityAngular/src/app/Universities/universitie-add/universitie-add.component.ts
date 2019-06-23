import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Shared/api.service';
import {  Router } from '@angular/router';


@Component({
  selector: 'app-universitie-add',
  templateUrl: './universitie-add.component.html',
  styleUrls: ['./universitie-add.component.css']
})
export class UniversitieAddComponent implements OnInit {

  constructor(private apiService:ApiService,private route:Router) { }

  ngOnInit() {
    this.apiService.univirsity={
      universityId:0,
      name:null,
      imageUrl:null

    }
  }

  
  
  submit(){
    this.apiService.saveUniversities().subscribe(res=>{
     this.route.navigate(['AllUniversities']);
    },
    err=>{
      console.log(err)
    }
    );

  }

}
