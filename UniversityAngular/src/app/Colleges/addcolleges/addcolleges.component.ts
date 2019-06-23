import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Shared/api.service';
import { College } from 'src/app/Models/college';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { University } from 'src/app/Models/university';

@Component({
  selector: 'app-addcolleges',
  templateUrl: './addcolleges.component.html',
  styleUrls: ['./addcolleges.component.css']
})
export class AddcollegesComponent implements OnInit {
  universitiers: University[];
  categoryForm: FormGroup;
   public response: {dbPath: ''};
   public uploadFinished = (event) => {
     this.response = event;
  }
  
  constructor(private apiService:ApiService,private route:Router,private formBuild: FormBuilder) { }


  ngOnInit() {

     
   
      
    this.createCategoryForm();

    this.apiService.getAllUniversities().subscribe(res=>this.universitiers=res as University[]);
    
  } 

   createCategoryForm() {
     this.categoryForm = this.formBuild.group({
       collegeId: 0,
      name: ['', Validators.required],
      imageUrl: ['', Validators.required],
      universityId: ['', Validators.required],
      
    });
   }

   addCategory() {
   this.categoryForm.controls['imageUrl'].setValue(this.response.dbPath);
   // console.log(this.categoryForm.value);
   // console.log(this.response.dbPath)
    this.apiService.saveColleges(this.categoryForm.value).subscribe(data => {  } ,
      err => {console.log(err); } );

   // this.route.navigate(['AllColleges']);
  }
  

}
