import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Shared/api.service';
import { College, BookQuery } from 'src/app/Models/college';
import { BookResult } from 'src/app/Models/book-result';

@Component({
  selector: 'app-search-college',
  templateUrl: './search-college.component.html',
  styleUrls: ['./search-college.component.css']
})
export class SearchCollegeComponent implements OnInit {
  Colleges:College[];
  


  constructor(private apiService:ApiService) { }

  ngOnInit() {
  this.apiService.college={
      collegeId:0,
      name:null,
      imageUrl:null,
      university:null,
      universityId:null,
    }
  }
   

  onQuery() {
    this.apiService.getSearchCollege(this.apiService.college.name).subscribe(res=>this.Colleges=res as College[])
  }

 
  

}
