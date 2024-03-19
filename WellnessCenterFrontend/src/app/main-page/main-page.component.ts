import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
    this.getMessages();
  }

  async getMessages() {
    try {
      let path: string = "http://localhost:8090/api/massage";
      let response = await fetch(path);
      let json = await response.json();
      console.log(json);
    } catch (error) {
      console.error('An error occurred:', error);
    }
  }
}
