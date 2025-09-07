import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Appointment } from '../model/appointment';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AppointmentService {
  private base = `${environment.apiUrl}/appointments`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(this.base);
  }

  get(id: number): Observable<Appointment> {
    return this.http.get<Appointment>(`${this.base}/${id}`);
  }

  create(a: Appointment): Observable<Appointment> {
    return this.http.post<Appointment>(this.base, a);
  }

  update(id: number, a: Appointment): Observable<Appointment> {
    return this.http.put<Appointment>(`${this.base}/${id}`, a);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.base}/${id}`);
  }
}
