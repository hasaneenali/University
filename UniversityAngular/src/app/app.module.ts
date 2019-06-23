import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AllUniversitiesComponent } from './Universities/all-universities/all-universities.component';
import { ApiService } from './Shared/api.service';
import { HttpModule, Http } from '@angular/http';
import { UniversitieAddComponent } from './Universities/universitie-add/universitie-add.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AllCollegesComponent } from './Colleges/all-colleges/all-colleges.component';
import { AddcollegesComponent } from './Colleges/addcolleges/addcolleges.component';
import { UploadComponent } from './Colleges/upload/upload.component';
import { SearchCollegeComponent } from './Colleges/search-college/search-college.component'

@NgModule({
  declarations: [
    AppComponent,
    AllUniversitiesComponent,
    UniversitieAddComponent,
    AllCollegesComponent,
    AddcollegesComponent,
    UploadComponent,
    SearchCollegeComponent,
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
