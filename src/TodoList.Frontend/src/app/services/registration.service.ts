import { Injectable } from '@angular/core';
import { RegistrationRequest } from '../models/registrationRequest';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class RegistrationService {
    constructor (private httpClient: HttpClient) {
    }

    public register(registrationRequest: RegistrationRequest) {
        return this.httpClient.post(`${environment.apiUrl}/api/user`, registrationRequest);
    }
}
