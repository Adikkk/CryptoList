import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'add-project-modal',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddProjectModalComponent implements OnInit {
  private baseUrl: string;
  addForm: FormGroup;
  isSubmitted = false;


  constructor(
    private fb: FormBuilder,
    public modal: NgbActiveModal,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
   }

  ngOnInit() {
    this.addForm = this.fb.group({
      name: ['', [Validators.required]],
      link: ['', [Validators.required]],
      description: ['', [Validators.required, Validators.minLength(10)]],
      category: ['', [Validators.required]],
      isoCode: ['', [Validators.required]],
      pictureUri: ['', [Validators.required]],
      isPremium: ['', []]
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.addForm.controls;
  }

  onSubmit() {
    this.isSubmitted = true;

    if(!this.addForm.valid) {
      return;
    }

    const data = {
      UserId: "572c7d0d-3eda-4c95-b7c2-c7572a3a953d",
      Name: this.f['name'].value,
      Link: this.f['link'].value,
      Description: this.f['description'].value,
      Category: this.f['category'].value,
      ISOCode: this.f['isoCode'].value,
      PictureUri: this.f['pictureUri'].value,
      IsPremium: this.f['isPremium'].value
    };

    console.log(data);

    this.http.post<any>(this.baseUrl + 'api/projects', data).subscribe(() => {
      this.modal.close();
      window.location.reload();
    });

  }

}
