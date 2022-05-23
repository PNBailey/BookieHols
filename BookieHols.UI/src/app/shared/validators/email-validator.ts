import { AbstractControl, AsyncValidatorFn, ValidationErrors } from "@angular/forms";
import { Observable } from "rxjs";
import { debounceTime, distinctUntilChanged, switchMap, map, first } from "rxjs/operators";
import { AccountService } from "src/app/services/account.service";

export class EmailValidator {

static uniqueEmailValidatorFn(accountService: AccountService): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors> => control.valueChanges
        .pipe(
        debounceTime(400),
        distinctUntilChanged(),
        switchMap(value => accountService.checkEmailUnique(value)),
        map((unique: boolean) => (unique ? null : {'emailUniquenessViolated': true})),
        first());
    }
}