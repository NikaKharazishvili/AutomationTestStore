# Automation QA — Final Task

Selenium WebDriver test automation project for [automationteststore.com](https://automationteststore.com), built with C# / xUnit.

---

## Tech stack

| Concern | Tool |
|---|---|
| Browser automation | Selenium WebDriver |
| Browsers | Chrome, Firefox |
| Test runner | xUnit |
| Assertions | FluentAssertions |
| Logging | Serilog (console + rolling daily file) |
| Locator strategy | CSS selectors only |
| Design patterns | Factory Method, Page Object Model |
| Configuration | `appsettings.json` (base URL, headless toggle, user data) |
| Parallelism | xUnit `MaxParallelThreads = 2` |

---

## Test scenarios

### UC-1 — Account creation
1. Open the home page and navigate to **Login or register**.
2. Click **Continue** under *I am a new customer*.
3. Fill in all required fields and submit the registration form.
4. Assert that the **My Account** page is displayed and contains the username.
5. Assert that the page header shows **Welcome back \<firstname\>**.

### UC-2 — Registration form validation
1. Open the registration form (same navigation as UC-1).
2. Submit the form with a blank login name, then repeat with values outside the valid range (fewer than 5 characters, more than 64, or non-alphanumeric).
3. Assert that the error **"Login name must be alphanumeric only and between 5 and 64 characters!"** is displayed in each case.

Validation cases are data-driven via `[Theory] / [InlineData]`.

### UC-3 — Special offers discount check
1. Click **Specials** in the main navigation.
2. Assert that every displayed product has both a new (discounted) price and an old (original) price — i.e. new price count equals old price count.

---

## Configuration

All runtime settings live in `Tests/appsettings.json`:

| Key | Description |
|---|---|
| `BaseUrl` | Target site URL |
| `Headless` | `"true"` / `"false"` — run browsers headlessly or visibly |
| `User:*` | Registration form data used by UC-1 |

Logs are written to the console during the run and saved to daily rolling files under `logs/ats-<date>.log`. Log level is `Debug` and above — every navigation step, element interaction, and assertion-relevant value is recorded.

Both Chrome and Firefox run in parallel — up to two browser instances simultaneously, keeping resource usage predictable.