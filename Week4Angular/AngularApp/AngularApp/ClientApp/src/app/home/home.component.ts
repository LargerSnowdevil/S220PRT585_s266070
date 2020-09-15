import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  Students: Student[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Student[]>(baseUrl + 'api/Students').subscribe(result => {
      this.Students = result;
    }, error => console.error(error));
  }
}

interface Student {
  id: number;
  name: string;
  roll: number;
}
