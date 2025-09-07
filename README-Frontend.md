# TatvaCare – Frontend (Angular)

This is the frontend app for the **TatvaCare Appointment Booking System**.  
It allows users to:
- View all appointments
- Book a new appointment
- Edit an appointment
- Cancel an appointment

---

## 🛠️ Tech Stack
- **Angular 12 (Visual Studio template)**
- **TypeScript**
- **Bootstrap 5** (for styling)
- **RxJS / HttpClient** (for API calls)

---

## 📂 Project Structure
```
ClientApp/
 ├── src/app/
 │   ├── models/appointment.ts
 │   ├── services/appointment.service.ts
 │   ├── components/
 │   │   ├── appointment-list.component.ts / .html
 │   │   └── appointment-form.component.ts / .html
 │   ├── app-routing.module.ts
 │   ├── app.module.ts
 │   └── app.component.ts / .html
 └── environments/environment.ts
```

---

## ⚙️ Setup & Run

### 1. Prerequisites
- Install **Node.js 16.x** (recommended for Angular 12)
- Install Angular CLI:
  ```bash
  npm install -g @angular/cli
  ```

### 2. Install dependencies
Inside the `ClientApp` folder:
```bash
npm install
```

### 3. Run frontend
Option A – via **Visual Studio (with SPA proxy)**  
- Just press **F5** in Visual Studio
- Angular will run via proxy   
- It will automatically talk to the API

Option B – run manually  
```bash
cd ClientApp
npm start
```
Angular runs on   
Make sure backend API is running 

---

## 🔗 API Connection
The frontend reads the backend API base URL from:

`src/environments/environment.ts`
```ts
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7220'
};
```

Update `apiUrl` if your backend runs on a different port.

---

## 🖼️ Screens
- **Appointment List** → shows all appointments in a table
- **Book Appointment** → form to create a new appointment
- **Edit Appointment** → edit form pre-filled with existing data
- **Cancel Appointment** → deletes an appointment

---

## ✅ Workflow
1. User opens Angular app
2. Angular calls ASP.NET Core API via `AppointmentService`
3. API returns JSON → Angular displays data
4. User actions (create/edit/delete) call API → DB updates → UI refreshes
