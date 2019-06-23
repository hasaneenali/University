import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Shared/api.service';
import { College } from 'src/app/Models/college';

@Component({
  selector: 'app-all-colleges',
  templateUrl: './all-colleges.component.html',
  styleUrls: ['./all-colleges.component.css']
})
export class AllCollegesComponent implements OnInit {

  Colleges:College[];
  constructor(private apiService:ApiService) { }

  ngOnInit() {
    this.apiService.getALLColleges().subscribe(res=>this.Colleges=res as College[]);
    console.log(this.Colleges);
  }

}
