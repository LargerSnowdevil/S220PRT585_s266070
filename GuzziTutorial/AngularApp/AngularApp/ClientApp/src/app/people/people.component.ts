import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonService } from '../services/person.service';
import { Person } from '../models/person';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {
  people$: Observable<Person[]>;

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.loadPeople();
  }

  loadPeople() {
    this.people$ = this.personService.getPeople();
  }

  delete(personId) {
    const ans = confirm('Do you want to delete the Person with Id:' + personId);

    if (ans) {
      this.personService.deletePerson(personId).subscribe((data) => { this.loadPeople(); });
    }
  }

}
