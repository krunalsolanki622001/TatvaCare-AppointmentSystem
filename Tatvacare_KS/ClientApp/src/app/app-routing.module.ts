import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentListComponent } from './components/appointment-list.component';
import { AppointmentFormComponent } from './components/appointment-form.component';

const routes: Routes = [
  { path: '', component: AppointmentListComponent },
  { path: 'new', component: AppointmentFormComponent },
  { path: 'edit/:id', component: AppointmentFormComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
