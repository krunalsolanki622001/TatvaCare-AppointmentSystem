import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../service/appointment.service';
import { Appointment } from '../model/appointment';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-appointment-form',
  templateUrl: './appointment-form.component.html'
})
export class AppointmentFormComponent implements OnInit {
  id?: number;
  model: Appointment = { patientName: '', doctorName: '', startTime: '', endTime: '' };
  error = '';

  constructor(private api: AppointmentService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      this.id = +param;
      this.api.get(this.id).subscribe(a => {
        this.model = {
          id: a.id,
          patientName: a.patientName,
          doctorName: a.doctorName,
          startTime: a.startTime.substring(0, 16),
          endTime: a.endTime.substring(0, 16)
        };
      });
    }
  }

  save() {
    debugger;
    const payload: Appointment = {
      patientName: this.model.patientName.trim(),
      doctorName: this.model.doctorName.trim(),
      startTime: new Date(this.model.startTime).toISOString(),
      endTime: new Date(this.model.endTime).toISOString()
    };

    const req: Observable<any> = this.id
      ? this.api.update(this.id, payload)
      : this.api.create(payload);

    req.subscribe({
      next: () => {
        this.router.navigateByUrl('/');
      },
      error: (e: any) => {
        this.error = e?.error?.message || 'Failed to save appointment.';
      }
    });
  }
}
