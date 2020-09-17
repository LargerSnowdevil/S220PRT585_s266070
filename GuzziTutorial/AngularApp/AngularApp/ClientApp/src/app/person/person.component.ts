import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { PersonService } from '../services/person.service';
import { Person } from '../models/person';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent implements OnInit {
  people$: Observable<Person>;
  personId: number;

  constructor(private personService: PersonService, private avRoute: ActivatedRoute) {
    const idParam = 'id';

    if (this.avRoute.snapshot.params[idParam]) {
      this.personId =this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit(): void {
    this.loadPerson();
  }

  loadPerson() {
    this.people$ = this.personService.getPerson(this.personId);
  }

}
