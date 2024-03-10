import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthorizeService } from '../authorize.service';
import { Register } from '../models/register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public form: FormGroup = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  constructor(private authService: AuthorizeService) { }

  ngOnInit() {

  }

  public registerHandler() {
    if (this.form.valid) {
      const user: Register = { ...new Register(), ...this.form.value }

      this.authService.register(user).subscribe(result => {
        console.log(result);
      });
    }
  }

}
