import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthorizeService } from '../authorize.service';
import { Login } from '../models/login';
import { JwtHelperService } from '@auth0/angular-jwt';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public form: FormGroup = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  constructor(private authService: AuthorizeService,
    private jwtHelper: JwtHelperService) { }

  ngOnInit() {
  }


  public async loginHandler() {
    if (this.form.valid) {
      const user: Login = { ...new Login(), ...this.form.value }
      try{
        const jwt = await lastValueFrom(this.authService.login(user));
        console.log(jwt);
        // (jwt => {
        //   console.log(jwt);
        //   if (jwt) {
        //     localStorage.setItem('jwt', JSON.stringify(jwt))
        //     console.log(this.jwtHelper.decodeToken(jwt.accessToken))
        //     // localStorage.setItem('user', this.jwtHelper.decodeToken(jwt.accessToken) ?? '')
        //   }
        // });
      }
      catch(e){
        console.log(e);
      }
    }
  }

}
