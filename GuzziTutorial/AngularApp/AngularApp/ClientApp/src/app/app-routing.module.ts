import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PeopleComponent } from './people/people.component';
import { PersonComponent } from './person/person.component';
import { PersonAddEditComponent } from './person-add-edit/person-add-edit.component';

const routes: Routes = [
  { path: '', component: PeopleComponent, pathMatch: 'full' },
  { path: 'person/:id', component: PersonComponent },
  { path: 'add', component: PersonAddEditComponent },
  { path: 'person/edit/:id', component: PersonAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
