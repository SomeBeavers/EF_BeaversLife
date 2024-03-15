using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgreSQL_Core_App.Migrations
{
    /// <inheritdoc />
    public partial class CreateSchoolDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "bytea", nullable: false),
                    ProductVersion = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Administrator = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School.Student", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Pets", x => x.PetID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViewDepartmentCourseCounts",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "integer", nullable: false),
                    DepartmentName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CourseCount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "integer", nullable: false),
                    DepartmentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School.Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Department",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignment", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_OfficeAssignment_Person",
                        column: x => x.InstructorID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "PersonPet",
                columns: table => new
                {
                    PersonPeoplePersonId = table.Column<int>(type: "integer", nullable: false),
                    PetPetsPetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPet", x => new { x.PersonPeoplePersonId, x.PetPetsPetId });
                    table.ForeignKey(
                        name: "FK_PersonPet_Person_PersonPeoplePersonId",
                        column: x => x.PersonPeoplePersonId,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPet_Pets_PetPetsPetId",
                        column: x => x.PetPetsPetId,
                        principalTable: "Pets",
                        principalColumn: "PetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePerson",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "integer", nullable: false),
                    PeoplePersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePerson", x => new { x.CoursesCourseId, x.PeoplePersonId });
                    table.ForeignKey(
                        name: "FK_CoursePerson_Course_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePerson_Person_PeoplePersonId",
                        column: x => x.PeoplePersonId,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineCourse",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "integer", nullable: false),
                    URL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCourse", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_OnlineCourse_Course",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "OnsiteCourse",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Days = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnsiteCourse", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_OnsiteCourse_Course",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "StudentGrade",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseID = table.Column<int>(type: "integer", nullable: false),
                    StudentID = table.Column<int>(type: "integer", nullable: false),
                    Grade = table.Column<decimal>(type: "numeric(3,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrade", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_StudentGrade_Course",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_StudentGrade_Student",
                        column: x => x.StudentID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalInfos",
                columns: table => new
                {
                    AdditionalInfoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentGradeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInfos", x => x.AdditionalInfoID);
                    table.ForeignKey(
                        name: "FK_AdditionalInfo_StudentGrade",
                        column: x => x.StudentGradeId,
                        principalTable: "StudentGrade",
                        principalColumn: "EnrollmentID");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentGradeEnrollmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_StudentGrade_StudentGradeEnrollmentId",
                        column: x => x.StudentGradeEnrollmentId,
                        principalTable: "StudentGrade",
                        principalColumn: "EnrollmentID");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalTables",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalTables", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdditionalTable_Comment",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId");
                });

            migrationBuilder.CreateTable(
                name: "CommentTag",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTag", x => new { x.CommentId, x.TagId });
                    table.ForeignKey(
                        name: "FK_CommentTag_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Likes_Comment",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_StudentGradeId",
                table: "AdditionalInfos",
                column: "StudentGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalTables_CommentId",
                table: "AdditionalTables",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StudentGradeEnrollmentId",
                table: "Comment",
                column: "StudentGradeEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTag_TagId",
                table: "CommentTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePerson_PeoplePersonId",
                table: "CoursePerson",
                column: "PeoplePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPet_PetPetsPetId",
                table: "PersonPet",
                column: "PetPetsPetId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_CourseID",
                table: "StudentGrade",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_StudentID",
                table: "StudentGrade",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "AdditionalInfos");

            migrationBuilder.DropTable(
                name: "AdditionalTables");

            migrationBuilder.DropTable(
                name: "CommentTag");

            migrationBuilder.DropTable(
                name: "CoursePerson");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "OfficeAssignment");

            migrationBuilder.DropTable(
                name: "OnlineCourse");

            migrationBuilder.DropTable(
                name: "OnsiteCourse");

            migrationBuilder.DropTable(
                name: "PersonPet");

            migrationBuilder.DropTable(
                name: "ViewDepartmentCourseCounts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "StudentGrade");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
