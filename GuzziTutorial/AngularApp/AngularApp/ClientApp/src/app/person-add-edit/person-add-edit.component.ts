import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PersonService } from '../services/person.service';
import { Person } from '../models/person';

@Component({
  selector: 'app-person-add-edit',
  templateUrl: './person-add-edit.component.html',
  styleUrls: ['./person-add-edit.component.scss']
})
export class PersonAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formFirstName: string;
  personId: number;
  errorMessage: any;
  existingPerson: Person;

  constructor(private personService: PersonService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formFirstName = 'firstName';

    if (this.avRoute.snapshot.params[idParam]) {
      this.personId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group({
      personId: 0,
      firstName: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    if (this.personId > 0) {
      this.actionType = 'Edit';
      this.personService.getPerson(this.personId).subscribe(data => (
        this.existingPerson = data,
        this.form.controls[this.formFirstName].setValue(data.firstName)
      ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let person: Person = {
        firstName: this.form.get(this.formFirstName).value
      };

      this.personService.savePerson(person).subscribe((data) => {
        this.router.navigate(['/person', data.personId]);
      });
    }

    if (this.actionType === 'Edit') {
      let person: Person = {
        personId: this.existingPerson.personId,
        firstName: this.form.get(this.formFirstName).value
      };

      this.personService.updatePerson(person.personId, person).subscribe((data) => {
        this.router.navigate(['/']);
      });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get firstName() { return this.form.get(this.formFirstName); }

}
