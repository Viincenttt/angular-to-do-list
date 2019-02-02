import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserLoginRequest } from 'src/app/models/authentication/userloginrequest';
import { UserLoginResponse } from 'src/app/models/authentication/userloginresponse';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthService {
    private currentUserSubject: BehaviorSubject<UserLoginResponse>;
    public currentUser: Observable<UserLoginResponse>;

    constructor (private httpClient: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<UserLoginResponse>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): UserLoginResponse {
        return this.currentUserSubject.value;
    }

    public login(email: string, password: string) {
        const userLoginRequest = new UserLoginRequest(email, password);

        return this.httpClient.post<UserLoginResponse>(`${environment.apiUrl}/api/user/login`, userLoginRequest)
            .pipe(map(userLoginResponse => {
                if (userLoginResponse.succeeded) {
                    localStorage.setItem('currentUser', JSON.stringify(userLoginResponse));
                    this.currentUserSubject.next(userLoginResponse);
                }

                return userLoginResponse;
            }));
    }

    public logout(): void {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}