import { Injectable } from '../../../node_modules/@angular/core';
import { HttpInterceptor, HttpHandler, HttpEvent, HttpErrorResponse, HttpRequest,
HTTP_INTERCEPTORS } from '../../../node_modules/@angular/Common/http';
import { catchError } from '../../../node_modules/rxjs/operators';
import { Observable, throwError } from '../../../node_modules/rxjs';

// its a class created to intercept the error of the web app.
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                if (error instanceof HttpErrorResponse) {
                    if (error.status === 401) {
                        return throwError(error.statusText);
                    }
                    const applicationError = error.headers.get('Application-Error');
                    // check if its an application-Error
                    if (applicationError) {
                        console.error(applicationError);
                        return throwError(applicationError);
                    }
                    // then we get the server Error inside this error.error.
                    const serverError = error.error;
                    let modalStateErrors = '';
                    // the following method accomodate all the different error that the API can throw.
                    // we check if its type of object.
                    if (serverError && typeof serverError === 'object') {
                        for (const key in serverError) {
                            if (serverError[key]) {
                                modalStateErrors += serverError[key] + '\n';
                            }
                        }
                    }
                        // we return the the modalstate error if available or serverError and if none 'server Error'.
                    return throwError(modalStateErrors || serverError || 'Server Error');
                }
            })
        );
    }
}
export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
};
