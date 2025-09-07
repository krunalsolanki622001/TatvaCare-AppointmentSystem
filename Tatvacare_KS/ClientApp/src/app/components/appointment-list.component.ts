import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../service/appointment.service';
import { Appointment } from '../model/appointment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html'
})
export class AppointmentListComponent implements OnInit {
  list: Appointment[] = [];

  constructor(private api: AppointmentService, private router: Router) { }

  ngOnInit() {
    this.load();
  }

  load() {
    this.api.getAll().subscribe(d => this.list = d);
  }

  remove(a: Appointment) {
    if (a.id && confirm('Cancel this appointment?')) {
      this.api.delete(a.id).subscribe(() => this.load());
    }
  }
}
