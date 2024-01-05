import { AuthService } from './../../services/auth.service';
import { Component } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  
  constructor( public formBuilder: FormBuilder, private router: Router, private loginService: LoginService, public authService: AuthService) {

  }

  loginForm: FormGroup;

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group
    (
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]]
      }
    )

  }

  get dataForm() {
    return this, this.loginForm.controls;
  }

  loginUser() {
    this.loginService.login(this.dataForm["email"].value, this.dataForm["password"].value).subscribe(
      token => { 
        this.authService.setToken(token);
        this.authService.setEmailUser(this.dataForm["email"].value);
        this.authService.authUser(true);
        this.router.navigate(['/dashboard']);
      },
      err => {
        alert('Ocorreu um erro')
      }

    )
  }

}
