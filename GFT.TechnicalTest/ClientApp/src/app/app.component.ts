import { Component, OnInit } from '@angular/core';

import { MsalService } from '@azure/msal-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Hiperpass';

  public sidebarColor = 'red';
  public showDashboard = true;
  public loggedIn = false;

  constructor(private authService: MsalService) {
  }

  ngOnInit() {
    this.checkoutAccount();
  }

  changeSidebarColor(color) {
    const sidebar = document.getElementsByClassName('sidebar')[0];
    const mainPanel = document.getElementsByClassName('main-panel')[0];

    this.sidebarColor = color;

    if (sidebar) {
      sidebar.setAttribute('data', color);
    }

    if (mainPanel) {
      mainPanel.setAttribute('data', color);
    }
  }

  changeDashboardColor(color) {
    const body = document.getElementsByTagName('body')[0];

    if (body && color === 'white-content') {
      body.classList.add(color);

    } else if (body.classList.contains('white-content')) {
      body.classList.remove('white-content');
    }
  }

  onActivate(event: any) {
    this.showDashboard = false;
    console.log(event);
  }

  private checkoutAccount() {
    this.loggedIn = !!this.authService.getAccount();
  }
}
