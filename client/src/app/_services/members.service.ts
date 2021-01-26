import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root',
})
export class MembersService {
  baseurl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMembers() {
    return this.http.get<Array<Member>>(this.baseurl + 'users');
  }
  getMember(username) {
    return this.http.get<Member>(this.baseurl + 'users/' + username);
  }
  updateMember(member: Member) {
    return this.http.put(this.baseurl + 'users', member);
  }
}
