import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Main Page',  icon: 'dashboard', class: '' },
    { path: '/user-profile', title: 'User Information',  icon:'person', class: '' },
    { path: '/table-list', title: 'All transactions',  icon:'content_paste', class: '' },
    { path: '/typography', title: 'Transfer',  icon:'library_books', class: '' },
    { path: '/icons', title: 'Graphs',  icon:'bubble_chart', class: '' },
    { path: '/maps', title: 'Credit',  icon:'location_on', class: '' },
    { path: '/notifications', title: 'Newest information',  icon:'notifications', class: '' },
    { path: '/upgrade', title: 'Settings',  icon:'unarchive', class: 'active-pro' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
