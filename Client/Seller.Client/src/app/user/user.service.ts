import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from "../../environments/environment"

@Injectable({
  providedIn: 'root'
})
export class UserService implements OnInit{

  userId: string
  token: string;
  username: string;

  constructor(private http:HttpClient) { }

  private loginPath = environment.apiUrl + '/identity/login'
  private registerPath = environment.apiUrl + '/identity/register'

  ngOnInit(){
    this.userId = this.getUserId()
    this.token = this.getToken()
    this.username = this.getUsername() 
  }

  login(data): Observable<any>{
    return this.http.post(this.loginPath, data)
    
  }

  register(data): Observable<any>{
    return this.http.post(this.registerPath, data)
  }

  saveToken(userId, token, username){
    localStorage.setItem('userId', userId)
    localStorage.setItem('token', token)
    localStorage.setItem('username', username)
  }

  getUserId(){
    return localStorage.getItem('userId');
  }

  getToken(){
    return localStorage.getItem('token');
  }

  getUsername(){
    return localStorage.getItem('username');
  }

  logout() {
    localStorage.removeItem('userId')
    localStorage.removeItem('token')
    localStorage.removeItem('username')
    this.userId = null;
    this.token = null;
    this.username = null;
    this.getToken()
    this.getUsername()  
  }
}
