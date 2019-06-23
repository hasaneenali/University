import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { University } from '../Models/university';
import { College, BookQuery} from '../Models/college';
import { map } from 'rxjs/operators';
import { BookResult } from '../Models/book-result';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  univirsity:University;
  college:College;

  readonly rotUrl="https://localhost:44384/api";
  
  constructor(private http:HttpClient) { }
  
  getAllUniversities(){
  
    return this.http.get(this.rotUrl + '/Universities')
    
  }

  saveUniversities(){
    return this.http.post(this.rotUrl+'/Universities',this.univirsity);
  }

  getALLColleges(){
    return this.http.get(this.rotUrl+ '/Colleges')
  }
  
saveColleges(college:College){
  return this.http.post(this.rotUrl+ '/CollegesAngular',college);
}

getSearchCollege(SearchName:string){
  return this.http.get('https://localhost:44384/api/Colleges/Search/' + SearchName);
}



}


