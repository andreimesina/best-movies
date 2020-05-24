import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Company } from '../../shared/company.model';
import { ApiService } from '../../shared/api.service';


@Component({
  selector: 'app-edit-company-modal',
  templateUrl: './edit-company-modal.component.html',
  styleUrls: ['./edit-company-modal.component.css']
})
export class EditCompanyModalComponent {
  @ViewChild('editCompanyModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editCompanyForm: FormGroup;
  currentCompany = new Company();

  constructor(public fb: FormBuilder, private api: ApiService) { }

  initialize(id: number): void {
    this.modal.show();
    this.api.getCompany(id)
      .subscribe((data: Company) => {
        this.currentCompany = data;
        this.currentCompany.id = id;
        this.initializeFrom(this.currentCompany);
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  initializeFrom(currentCompany: Company) {
    this.editCompanyForm = this.fb.group({
      name: [currentCompany.name, Validators.required],
      movieId: ['', Validators.required]
    });
  }

  editCompany() {
    const editedCompany = new Company({
      id: this.currentCompany.id,
      name: this.editCompanyForm.value.name,
      movieId: this.editCompanyForm.value.movieId
    });

    this.api.editCompany(editedCompany)
      .subscribe(() => {
        this.change.emit('company');
        this.modal.hide();
      },
        (error: Error) => {
          console.log('err', error);
        });
  }
}