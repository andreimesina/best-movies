import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  options = ['Movie', 'Actor', 'Company'];
  selectedOption = 'Movie';
  currentFormRef: any;
  addMovieForm: FormGroup;
  addActorForm: FormGroup;
  addCompanyForm: FormGroup;
  success: boolean;

  constructor(public fb: FormBuilder, private api: ApiService) { }

  ngOnInit() {

    this.addMovieForm = this.fb.group({
      title: [null, Validators.required],
      releaseDate: [null, Validators.required],
      runtime: [null, Validators.required],
      actorId: [null, Validators.required],
      companyId: [null, Validators.required],
      genreId: [null, Validators.required],
      img: [null]
    });

    this.addActorForm = this.fb.group({
      name: [null, Validators.required],
    });

    this.addCompanyForm = this.fb.group({
      name: [null, Validators.required],
    });

    this.currentFormRef = this.addMovieForm;
  }

  radioChange(event: any) {
    this.selectedOption = event.target.value;
    this.currentFormRef = this['add' + this.selectedOption + 'Form'];
  }

  add() {
    this.api['add' + this.selectedOption](this.currentFormRef.value).subscribe(() => {
      this.currentFormRef.reset();
      this.success = true;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
      (error: Error) => {
        console.log(error);
        this.currentFormRef.reset();
        this.success = false;
        setTimeout(() => {
          this.success = null;
        }, 3000);
      });
  }
}