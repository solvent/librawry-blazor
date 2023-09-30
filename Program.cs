using librawry.portable;
using librawry.portable.ef;
using librawry.portable.repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var cons = builder.Configuration.GetConnectionString("SqliteDatabase");

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<LibrawryContext>(options => options.UseSqlite(cons));
builder.Services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
	app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
