import { Component, OnInit } from '@angular/core';
import { KnownRoutes, RouteInfo } from '../../app-routing.module';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  menuItems: RouteInfo[];

  ngOnInit() {
    this.menuItems = KnownRoutes
      .filter(menuItem => menuItem)
      .sort((a, b) => a.title.localeCompare(b.title));
  }

  isMobileMenu() {
    return window.innerWidth <= 991;
  }
}
