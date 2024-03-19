import { Component } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent {
  showMainPageComponent: boolean = true;
  showLoginComponent: boolean = false;
  showRegistrationComponent: boolean = false;
  showMainPage(){
    console.log("btn MainPage click");
    this.showMainPageComponent = true;
    this.showLoginComponent = false;
    this.showRegistrationComponent = false;
  }

  showLogin() {
    console.log("btn Login click");
    this.showMainPageComponent = false;
    this.showLoginComponent = true;
    this.showRegistrationComponent = false;
  }

  showRegistration() {
    console.log("btn Registration click");
    this.showMainPageComponent = false;
    this.showLoginComponent = false;
    this.showRegistrationComponent = true;
  }
}
