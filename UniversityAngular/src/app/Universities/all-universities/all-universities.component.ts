import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Shared/api.service';
import { University } from 'src/app/Models/university';



@Component({
  selector: 'app-all-universities',
  templateUrl: './all-universities.component.html',
  styleUrls: ['./all-universities.component.css']
})
export class AllUniversitiesComponent implements OnInit {

  
  Universities:University[];
  constructor(private apiService:ApiService) { }

  ngOnInit() {
    this.apiService.getAllUniversities().subscribe(res=>this.Universities=res as University[]);
    console.log(this.Universities)

  }

}
