import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  userLoggedIn = false;
  username = '';
  password = '';
  statusMsg = 'Enter username and password.';
  private _isProcessingLogin = false;
  currentTime = new Date();

  signInForm = new FormGroup({
    username: new FormControl('', [Validators.minLength(2), Validators.required]),
    password: new FormControl('', [Validators.minLength(4), Validators.required]),
  });

  constructor(public http: HttpClient, @Inject('API_URL') public apiUrl: string) {
    console.log(apiUrl);
    // http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
  }

  

  ngOnInit() {
      setInterval(() => {
        this.currentTime = new Date();
      }, 1000);
  }

  login(type: string) {
    if (this.username.length > 0 && this.password.length > 0 && this._isProcessingLogin === false) {
        this._isProcessingLogin = true;
        this.logTime(type);
        // switch (type) {
        //   case 'clockIn':
        //     this.clockIn();
        //     break;
        //   case 'clockOut':
        //     this.clockOut();
        //     break;
        //   case 'break':
        //     this.break();
        //     break;
        // }
    }

  }

  private clockIn() {
    
    console.log('clocking in');
  }

  private clockOut() {
    
    console.log('clocking out');
  }

  private break() {
    this.clearForm();
    console.log('going on break');
  }

  private clearForm() {
    this._isProcessingLogin = false;
    this.username = '';
    this.password = '';
  }

  private async logTime(type: string) {
    const data = {
      username: this.username,
      password: this.password,
      logType: type
    };

    this.http.post(this.apiUrl + 'TimeLogs/LogTime', data).subscribe(result => {
      console.log(result);
      this.clearForm();
    }, error => {
      this.statusMsg = error.error;
      console.error(error);
    });
  }

}
