import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root',
})
export class MembersService {
  baseurl = environment.apiUrl;
  members:Array<Member>=[];

  constructor(private http: HttpClient) {}

  getMembers() {
    if(this.members.length>0) return of(this.members);
    return this.http.get<Array<Member>>(this.baseurl + 'users').pipe(
      map(members=>{
          this.members=members;
          return members;
      })
    );
  }
  getMember(username) {
    const member=this.members.find(x=>x.userName===username);
    if(member!==undefined){
      return of(member);
    }
    return this.http.get<Member>(this.baseurl + 'users/' + username);
  }
  updateMember(member: Member) {
    return this.http.put(this.baseurl + 'users', member).pipe(
      map(()=>{
        const index=this.members.indexOf(member);
        this.members[index]=member;
      })
    );
  }
}
