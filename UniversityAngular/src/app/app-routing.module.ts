import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllUniversitiesComponent } from './Universities/all-universities/all-universities.component';
import { UniversitieAddComponent } from './Universities/universitie-add/universitie-add.component';
import { AllCollegesComponent } from './Colleges/all-colleges/all-colleges.component';
import { AddcollegesComponent } from './Colleges/addcolleges/addcolleges.component';
import { SearchCollegeComponent } from './Colleges/search-college/search-college.component';

const routes: Routes = [
  {path:'AllUniversities',component:AllUniversitiesComponent},
  {path:'addUniversities',component:UniversitieAddComponent},
  {path:'AllColleges',component:AllCollegesComponent},
  {path:'Addco',component:AddcollegesComponent},
  {path:'search',component:SearchCollegeComponent},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
