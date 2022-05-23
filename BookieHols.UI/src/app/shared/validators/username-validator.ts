import { AbstractControl, AsyncValidatorFn, ValidationErrors } from "@angular/forms";
import { Observable } from "rxjs";
import { debounceTime, distinctUntilChanged, switchMap, map, first } from "rxjs/operators";
import { AccountService } from "src/app/services/account.service";

export class UsernameValidator {

static uniqueUsernameValidatorFn(accountService: AccountService): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors> => control.valueChanges
        .pipe(
        debounceTime(400),
        distinctUntilChanged(),
        switchMap(value => accountService.checkUsernameUnique(value)),
        map((unique: boolean) => (unique ? null : {'usernameUniquenessViolated': true})),
        first());
    }
}