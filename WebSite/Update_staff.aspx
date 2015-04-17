<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update_staff.aspx.cs" Inherits="Update_staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <!--
    DeVry Senior Project
    CIS 470
    Team C
    Jeremy Adams
    Taunyl Bailey
    Tim Olson
    Rachel Spiegelhoff
    -->


<!-- Update_staff.aspx
    --------------------- Work Log -----------------------
    7/23/2014 - JA - Setup form fields
    7/24/2014 - JA - Implement image uploads
 -->
    <div class="content-header">
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
&nbsp;- Resume</div>
    <div class="content">
        <asp:Panel ID="PnlAccount" runat="server" DefaultButton="btnUpdate" style="text-align: center">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        
            <br />
            <table>
                <tr>
                    <td style="width: 354px; height: 222px;">
                        <asp:Label ID="lblUsername" runat="server" style="text-align: left" Font-Bold="True" ForeColor="#7FB141"></asp:Label>
                        <br />ID:
                        <asp:Label ID="lblUserid" runat="server"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <strong>Contact Info:</strong> <a href="Account.aspx">[edit]</a><br />
                        Phone:
                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
                        <br />
                        E-Mail:
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                        
                        </td>
                    <td style="width: 190px; text-align: left; height: 222px;">
                        <asp:HiddenField ID="HiddenName" runat="server" />
                        <asp:HiddenField ID="HiddenPicSrc" runat="server" />
                        <asp:HiddenField ID="HiddenUserid" runat="server" />
                        <asp:HiddenField ID="HiddenUsername" runat="server" />
                        <asp:HiddenField ID="HiddenPhone" runat="server" />
                        <asp:HiddenField ID="HiddenEmail" runat="server" />
                    </td>
                    <td style="width: 264px; text-align: center; height: 222px;">
                        <asp:Image ID="ImgPic" runat="server" ImageUrl="~/images/male_avatar.jpg" style="text-align: center" />
                        <br />
                        <asp:Label ID="lblUpload" runat="server" ForeColor="Red"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right; height: 22px;">&nbsp;</td>
                    <td style="text-align: center; width: 190px; height: 22px;">
                        &nbsp;</td>
                    <td style="width: 264px; height: 22px;">
                        <asp:FileUpload ID="FileImg" runat="server" Width="225px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right; height: 22px;"></td>
                    <td style="text-align: center; width: 190px; height: 22px;"></td>
                    <td style="width: 264px; height: 22px;">
                        <asp:Button ID="BtnUpload" Class="btn btn-primary" runat="server" Text="Upload" OnClick="BtnUpload_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right; height: 22px;">Job Title:&nbsp;</td>
                    <td style="text-align: left; width: 190px; height: 22px;">
                        <asp:DropDownList ID="DdField" Width="190px" runat="server">
                            <asp:ListItem>Choose</asp:ListItem>
                            <asp:ListItem>.Net Developer</asp:ListItem>
                            <asp:ListItem>Account Manager</asp:ListItem>
                            <asp:ListItem>Concrete Testing Technician</asp:ListItem>
                            <asp:ListItem>Acoustic Engineer II</asp:ListItem>
                            <asp:ListItem>Android / Linux Software Dev. Engineer</asp:ListItem>
                            <asp:ListItem>Application Developer</asp:ListItem>
                            <asp:ListItem>Applications Engineer</asp:ListItem>
                            <asp:ListItem>Applications Engineer C-H</asp:ListItem>
                            <asp:ListItem>Architectural Job Captain - C-H</asp:ListItem>
                            <asp:ListItem>ASME Support - C</asp:ListItem>
                            <asp:ListItem>Autocad Drafter</asp:ListItem>
                            <asp:ListItem>AutoCad Plant 3D Piping Designer</asp:ListItem>
                            <asp:ListItem>Automation Engineer</asp:ListItem>
                            <asp:ListItem>Batch Position</asp:ListItem>
                            <asp:ListItem>Batch/ETL Tester</asp:ListItem>
                            <asp:ListItem>BPM/SOA Middleware Architecture</asp:ListItem>
                            <asp:ListItem>Bridge Engineer 3</asp:ListItem>
                            <asp:ListItem>Build and Release Engineer</asp:ListItem>
                            <asp:ListItem>Busines Systems Analyst</asp:ListItem>
                            <asp:ListItem>Buyer</asp:ListItem>
                            <asp:ListItem>Buyer - Machine and Metal Parts</asp:ListItem>
                            <asp:ListItem>Buyer/Planner</asp:ListItem>
                            <asp:ListItem>Buyers</asp:ListItem>
                            <asp:ListItem>C/S Engineer - FEA - ANSYS - C</asp:ListItem>
                            <asp:ListItem>CAD Designer</asp:ListItem>
                            <asp:ListItem>CAD Drafters - CATIA</asp:ListItem>
                            <asp:ListItem>CAD/PDM Designer</asp:ListItem>
                            <asp:ListItem>CAE Analyst</asp:ListItem>
                            <asp:ListItem>CAE Body/Catia V5</asp:ListItem>
                            <asp:ListItem>Chemical Operator</asp:ListItem>
                            <asp:ListItem>Civil / Structural Design Engineer – Youngstown</asp:ListItem>
                            <asp:ListItem>Civil CAD Designer / Technician - T/P</asp:ListItem>
                            <asp:ListItem>Civil CAD Technician</asp:ListItem>
                            <asp:ListItem>Civil Design Engineer</asp:ListItem>
                            <asp:ListItem>Civil Eng./ PM-D</asp:ListItem>
                            <asp:ListItem>Civil Engineer</asp:ListItem>
                            <asp:ListItem>Civil Engineer - T/P</asp:ListItem>
                            <asp:ListItem>Civil Engineer -C-H</asp:ListItem>
                            <asp:ListItem>Civil Engineer / Surveyor</asp:ListItem>
                            <asp:ListItem>Civil Engineer V</asp:ListItem>
                            <asp:ListItem>Civil Site Design Engineer</asp:ListItem>
                            <asp:ListItem>Civil/Mechanical Engineer - DP</asp:ListItem>
                            <asp:ListItem>Civil/Structural Engineer - P.E.</asp:ListItem>
                            <asp:ListItem>CNC Machinists</asp:ListItem>
                            <asp:ListItem>Coating Inspector-C</asp:ListItem>
                            <asp:ListItem>Colonel Hacker Developer Position</asp:ListItem>
                            <asp:ListItem>Contracts and Risk Manager</asp:ListItem>
                            <asp:ListItem>Contracts Specialist/Project Assistant</asp:ListItem>
                            <asp:ListItem>Controls Engineer I - C</asp:ListItem>
                            <asp:ListItem>Corp. Resolution Specialist</asp:ListItem>
                            <asp:ListItem>Corrosion Engineer</asp:ListItem>
                            <asp:ListItem>Data Analyst</asp:ListItem>
                            <asp:ListItem>Data Analyst/Business Analyst</asp:ListItem>
                            <asp:ListItem>Data Management</asp:ListItem>
                            <asp:ListItem>Data Modeler</asp:ListItem>
                            <asp:ListItem>Database Developer (Oracle Engineer)</asp:ListItem>
                            <asp:ListItem>Demand Planner</asp:ListItem>
                            <asp:ListItem>Design Engineer</asp:ListItem>
                            <asp:ListItem>Design Engineer - Heavy Equip Handling</asp:ListItem>
                            <asp:ListItem>Design Engineer-C-H</asp:ListItem>
                            <asp:ListItem>Designer</asp:ListItem>
                            <asp:ListItem>Designer/Drafter</asp:ListItem>
                            <asp:ListItem>Desktop Engineer</asp:ListItem>
                            <asp:ListItem>Developer Position</asp:ListItem>
                            <asp:ListItem>Director, Customer Experience Reporting</asp:ListItem>
                            <asp:ListItem>Director, Theme Park Ride Maintenance Operations</asp:ListItem>
                            <asp:ListItem>Document Control</asp:ListItem>
                            <asp:ListItem>Drafter</asp:ListItem>
                            <asp:ListItem>Drafter autocad telecomm</asp:ListItem>
                            <asp:ListItem>DSP Process Engineer</asp:ListItem>
                            <asp:ListItem>E/M Assemblers</asp:ListItem>
                            <asp:ListItem>EE-Antennas</asp:ListItem>
                            <asp:ListItem>Electrical Controls Engineer / Project Manager</asp:ListItem>
                            <asp:ListItem>Electrical Designer</asp:ListItem>
                            <asp:ListItem>Electrical Designer - C/H</asp:ListItem>
                            <asp:ListItem>Electrical Engineer</asp:ListItem>
                            <asp:ListItem>Electrical Engineer II</asp:ListItem>
                            <asp:ListItem>Electrical Engineer-C-H</asp:ListItem>
                            <asp:ListItem>Electrical Engineer-D</asp:ListItem>
                            <asp:ListItem>Electrical Engineer-Wire Harness</asp:ListItem>
                            <asp:ListItem>Electrical Systems Design Engineer - C</asp:ListItem>
                            <asp:ListItem>Electrical Systems Engineer</asp:ListItem>
                            <asp:ListItem>Electro-Mechanical Technician</asp:ListItem>
                            <asp:ListItem>Embedded Software Engineer</asp:ListItem>
                            <asp:ListItem>Embedded Software Engineer- Linux Kernel</asp:ListItem>
                            <asp:ListItem>Embedded Software Engineers</asp:ListItem>
                            <asp:ListItem>Engineer 2</asp:ListItem>
                            <asp:ListItem>Engineer 3</asp:ListItem>
                            <asp:ListItem>Engineer 4</asp:ListItem>
                            <asp:ListItem>Engineer II</asp:ListItem>
                            <asp:ListItem>Engineer II - Thermal Analysis - C</asp:ListItem>
                            <asp:ListItem>Engineer III</asp:ListItem>
                            <asp:ListItem>Engineering Project Lead-DP</asp:ListItem>
                            <asp:ListItem>Engineering/Survey Technician</asp:ListItem>
                            <asp:ListItem>Enterprise Architect with Financial Industry exp</asp:ListItem>
                            <asp:ListItem>Entry Level Inside Sales</asp:ListItem>
                            <asp:ListItem>Entry-Level Recruiter - Immediate Opening!</asp:ListItem>
                            <asp:ListItem>Environmental Engineer</asp:ListItem>
                            <asp:ListItem>Estimator</asp:ListItem>
                            <asp:ListItem>Excavation/Trenching Inspection (Utilities) - C</asp:ListItem>
                            <asp:ListItem>Expeditor</asp:ListItem>
                            <asp:ListItem>Expeditors</asp:ListItem>
                            <asp:ListItem>Facilities Engineer</asp:ListItem>
                            <asp:ListItem>Field Welding Inspectors-C</asp:ListItem>
                            <asp:ListItem>Final Test Technician 2nd & 3rd shift</asp:ListItem>
                            <asp:ListItem>Financial Manager II</asp:ListItem>
                            <asp:ListItem>Finite Element Analyst - C</asp:ListItem>
                            <asp:ListItem>Fire Protection Engineer - D</asp:ListItem>
                            <asp:ListItem>Flammability Certification Engineer</asp:ListItem>
                            <asp:ListItem>Focal Plane Engineer</asp:ListItem>
                            <asp:ListItem>Front-end Web Developer</asp:ListItem>
                            <asp:ListItem>Game Engineer</asp:ListItem>
                            <asp:ListItem>GIS Analyst</asp:ListItem>
                            <asp:ListItem>Graphics Compiler Test Engineer</asp:ListItem>
                            <asp:ListItem>Hardware Engineer</asp:ListItem>
                            <asp:ListItem>Help Desk Technician</asp:ListItem>
                            <asp:ListItem>HRIS Applications Support Specialist</asp:ListItem>
                            <asp:ListItem>HW Engineer-Analog</asp:ListItem>
                            <asp:ListItem>HW Technician</asp:ListItem>
                            <asp:ListItem>Hydraulics and Hydrology Engineer</asp:ListItem>
                            <asp:ListItem>Hydrologist-C-H</asp:ListItem>
                            <asp:ListItem>I & C Engineer-C-H</asp:ListItem>
                            <asp:ListItem>iM Project Manager</asp:ListItem>
                            <asp:ListItem>iM Project Manager</asp:ListItem>
                            <asp:ListItem>Industrial Design-Alias</asp:ListItem>
                            <asp:ListItem>Information Engineer IA/Firewall</asp:ListItem>
                            <asp:ListItem>Instrument/Electrical Design Specialist II</asp:ListItem>
                            <asp:ListItem>Instrumentation Engineer-C</asp:ListItem>
                            <asp:ListItem>Interaction Designer</asp:ListItem>
                            <asp:ListItem>International Services Administrator</asp:ListItem>
                            <asp:ListItem>INTools Designer</asp:ListItem>
                            <asp:ListItem>IT Business Analyst 2</asp:ListItem>
                            <asp:ListItem>IT Buyer</asp:ListItem>
                            <asp:ListItem>IT Project Manager</asp:ListItem>
                            <asp:ListItem>IT QA System Analyst</asp:ListItem>
                            <asp:ListItem>IT Technician</asp:ListItem>
                            <asp:ListItem>Java Backend Developer</asp:ListItem>
                            <asp:ListItem>Java Developer-Embedded-Paltronics</asp:ListItem>
                            <asp:ListItem>Java Front End Developer</asp:ListItem>
                            <asp:ListItem>Java Programmer</asp:ListItem>
                            <asp:ListItem>Java-/ Perl Developer</asp:ListItem>
                            <asp:ListItem>JDE-ERP Programmer Analyst</asp:ListItem>
                            <asp:ListItem>Jive Technician</asp:ListItem>
                            <asp:ListItem>Jr. Mechanical Engineer</asp:ListItem>
                            <asp:ListItem>Launch Fluids CAD Engineer</asp:ListItem>
                            <asp:ListItem>Lead Design Engineer</asp:ListItem>
                            <asp:ListItem>Lead Game Engineer</asp:ListItem>
                            <asp:ListItem>Lead Piping Designer-C</asp:ListItem>
                            <asp:ListItem>Lead Process Chemical Engineer</asp:ListItem>
                            <asp:ListItem>Lead Process Engineer</asp:ListItem>
                            <asp:ListItem>Lead Structural Engineer</asp:ListItem>
                            <asp:ListItem>Lean Enterprise Site Leader</asp:ListItem>
                            <asp:ListItem>LEAN Manufacturing Engineer</asp:ListItem>
                            <asp:ListItem>Linux Systems Administrator</asp:ListItem>
                            <asp:ListItem>Logistics Manager</asp:ListItem>
                            <asp:ListItem>Maintenance Engineer</asp:ListItem>
                            <asp:ListItem>Maintenance Technician</asp:ListItem>
                            <asp:ListItem>Manager, Test Engineering</asp:ListItem>
                            <asp:ListItem>Manufacturing Engineer</asp:ListItem>
                            <asp:ListItem>Manufacturing Engineer-DP</asp:ListItem>
                            <asp:ListItem>Manufacturing Process Engineer</asp:ListItem>
                            <asp:ListItem>Manufacturing Test Technician</asp:ListItem>
                            <asp:ListItem>Manufacturing/Process Engineer</asp:ListItem>
                            <asp:ListItem>Marketing Data Analyst</asp:ListItem>
                            <asp:ListItem>Master Scheduler</asp:ListItem>
                            <asp:ListItem>Mechanical Design Engineer</asp:ListItem>
                            <asp:ListItem>Mechanical Design Drafter</asp:ListItem>
                            <asp:ListItem>Mechanical Designer</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer - DP</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer - NRC Certified</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer 3</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer III</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer IV</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer-C-H</asp:ListItem>
                            <asp:ListItem>Mechanical Engineer-Pumps</asp:ListItem>
                            <asp:ListItem>Mechanical Interior Design Engineer</asp:ListItem>
                            <asp:ListItem>Mechanical Product Development Engineer</asp:ListItem>
                            <asp:ListItem>Mechanical Project Engineer</asp:ListItem>
                            <asp:ListItem>Mechanical Systems Engineer</asp:ListItem>
                            <asp:ListItem>MES Controls Engineer</asp:ListItem>
                            <asp:ListItem>Mid-Sr. Level Project Administrator</asp:ListItem>
                            <asp:ListItem>MTA - Safety Specialist IV</asp:ListItem>
                            <asp:ListItem>MTA - Assistant Electrical Engineer - Inspections</asp:ListItem>
                            <asp:ListItem>MTA - Associate Project Manager - Finance</asp:ListItem>
                            <asp:ListItem>MTA - CADD Drafter - Microstation</asp:ListItem>
                            <asp:ListItem>MTA - Construction Inspectors</asp:ListItem>
                            <asp:ListItem>MTA - Engineer - Level II</asp:ListItem>
                            <asp:ListItem>MTA - Engineering Technician I</asp:ListItem>
                            <asp:ListItem>MTA - Estimator - Bus Depot</asp:ListItem>
                            <asp:ListItem>MTA - Project Coordinator - Civil/Structural</asp:ListItem>
                            <asp:ListItem>MTA - Transit Management Analyst</asp:ListItem>
                            <asp:ListItem>MVC Developer</asp:ListItem>
                            <asp:ListItem>Naval Architect</asp:ListItem>
                            <asp:ListItem>Network Administrator</asp:ListItem>
                            <asp:ListItem>Network Analyst 2 - 25064</asp:ListItem>
                            <asp:ListItem>Network Architect</asp:ListItem>
                            <asp:ListItem>Network QA Engineer #3395914</asp:ListItem>
                            <asp:ListItem>Network Security Specialist</asp:ListItem>
                            <asp:ListItem>Network Service Engineer- DP</asp:ListItem>
                            <asp:ListItem>NOC Analyst</asp:ListItem>
                            <asp:ListItem>NX Design Engineer-</asp:ListItem>
                            <asp:ListItem>NX Designer-Modeling/Assembly</asp:ListItem>
                            <asp:ListItem>NX Designer-Surfacing</asp:ListItem>
                            <asp:ListItem>NYPA - Electrical Engineer - Metering</asp:ListItem>
                            <asp:ListItem>Openstack Cloud Developer</asp:ListItem>
                            <asp:ListItem>Operations / Production Planner</asp:ListItem>
                            <asp:ListItem>Operations Analyst 1</asp:ListItem>
                            <asp:ListItem>Oracle Apps DBA</asp:ListItem>
                            <asp:ListItem>PC-DMIS CMM Programmer / Operator</asp:ListItem>
                            <asp:ListItem>People Soft Project Engineer</asp:ListItem>
                            <asp:ListItem>Peoplesoft Developer</asp:ListItem>
                            <asp:ListItem>Pipe Stress Engineer-C</asp:ListItem>
                            <asp:ListItem>Piping Designers-C-H</asp:ListItem>
                            <asp:ListItem>Planner I</asp:ListItem>
                            <asp:ListItem>Planner I RMA</asp:ListItem>
                            <asp:ListItem>Platform Engineer</asp:ListItem>
                            <asp:ListItem>PLC Programmer</asp:ListItem>
                            <asp:ListItem>Power Supply Technician</asp:ListItem>
                            <asp:ListItem>Principal / Senior Principal Engineer ASIC Design</asp:ListItem>
                            <asp:ListItem>Principal RF/MS IC Design Engineer</asp:ListItem>
                            <asp:ListItem>Principal/ Staff Validation Engineer</asp:ListItem>
                            <asp:ListItem>Process Chemical/Mechanical Engineer</asp:ListItem>
                            <asp:ListItem>Process Engineer (Carlsbad) - D</asp:ListItem>
                            <asp:ListItem>Process Engineer (Chemical) - D</asp:ListItem>
                            <asp:ListItem>Process Engineer - C</asp:ListItem>
                            <asp:ListItem>Process Engineer - Test Carts - Thermal Control Sy</asp:ListItem>
                            <asp:ListItem>Process Engineer-C-H</asp:ListItem>
                            <asp:ListItem>Process Improvement Lead</asp:ListItem>
                            <asp:ListItem>Process Tech/SEM FIB Operator</asp:ListItem>
                            <asp:ListItem>Product Complaint / Regulatory Affairs Associate</asp:ListItem>
                            <asp:ListItem>Product Engineer</asp:ListItem>
                            <asp:ListItem>Product Engineer 2</asp:ListItem>
                            <asp:ListItem>Product Manager – Digital Sales</asp:ListItem>
                            <asp:ListItem>Production Planner</asp:ListItem>
                            <asp:ListItem>Program Manager - Engineering</asp:ListItem>
                            <asp:ListItem>PROGRAMMER – INTERMEDIATE/MID LEVEL</asp:ListItem>
                            <asp:ListItem>Programmer Analyst-C C++</asp:ListItem>
                            <asp:ListItem>Proj. Controls Manager - C/H</asp:ListItem>
                            <asp:ListItem>Project Architect-D</asp:ListItem>
                            <asp:ListItem>Project Controls Analyst-C-H</asp:ListItem>
                            <asp:ListItem>Project Controls II</asp:ListItem>
                            <asp:ListItem>Project Controls Specialist - C - PT</asp:ListItem>
                            <asp:ListItem>Project Engineer</asp:ListItem>
                            <asp:ListItem>Project Engineer Development Site Coordinator</asp:ListItem>
                            <asp:ListItem>Project Engineer IV-C</asp:ListItem>
                            <asp:ListItem>Project Engineer, Paint Shop Conveyor Engineer</asp:ListItem>
                            <asp:ListItem>Project Engineer- C</asp:ListItem>
                            <asp:ListItem>Project Engineer/Project Manager</asp:ListItem>
                            <asp:ListItem>Project Management - 23019</asp:ListItem>
                            <asp:ListItem>Project Management Specialist -23122</asp:ListItem>
                            <asp:ListItem>Project Manager</asp:ListItem>
                            <asp:ListItem>Project Manager (Mechanical)</asp:ListItem>
                            <asp:ListItem>Project Manager - Contract Manufacturing</asp:ListItem>
                            <asp:ListItem>Project Manager - Industrial Engineer, Mfg</asp:ListItem>
                            <asp:ListItem>Project Manager - Railway Vehicle Systems</asp:ListItem>
                            <asp:ListItem>Project Manager / Business Analyst</asp:ListItem>
                            <asp:ListItem>Project Manager – (Electrical & Controls)</asp:ListItem>
                            <asp:ListItem>Project Manager Hydro Electric</asp:ListItem>
                            <asp:ListItem>Project Surveyor</asp:ListItem>
                            <asp:ListItem>Project/Construction Manager</asp:ListItem>
                            <asp:ListItem>Python Backend Developer</asp:ListItem>
                            <asp:ListItem>QA Engineer</asp:ListItem>
                            <asp:ListItem>QA Inspectors</asp:ListItem>
                            <asp:ListItem>Quality Assurance Complaint Specialist II</asp:ListItem>
                            <asp:ListItem>Quality Assurance Complaint Specialist III</asp:ListItem>
                            <asp:ListItem>Quality Assurance Engineer</asp:ListItem>
                            <asp:ListItem>Quality Control Manager</asp:ListItem>
                            <asp:ListItem>Quality Director</asp:ListItem>
                            <asp:ListItem>Quality Engineer</asp:ListItem>
                            <asp:ListItem>Quality Engineer - F-35</asp:ListItem>
                            <asp:ListItem>Quality Engineer - MRB</asp:ListItem>
                            <asp:ListItem>Quality Engineer 2</asp:ListItem>
                            <asp:ListItem>Quality Engineer 3</asp:ListItem>
                            <asp:ListItem>Quality Engineer/CMM Programmer</asp:ListItem>
                            <asp:ListItem>Recruiter / Technical Recruiter - Sunnyvale</asp:ListItem>
                            <asp:ListItem>Recruiter / Technical Recruiter - Troy</asp:ListItem>
                            <asp:ListItem>Recruiter / Technical Recruiter - Woodland Hills</asp:ListItem>
                            <asp:ListItem>RF Test Technician</asp:ListItem>
                            <asp:ListItem>RFIC Engineer C H/or D 51106</asp:ListItem>
                            <asp:ListItem>RFIC Layout Manager</asp:ListItem>
                            <asp:ListItem>Sales Assistant</asp:ListItem>
                            <asp:ListItem>Sales Engineer-Rotating Equipment C-H</asp:ListItem>
                            <asp:ListItem>Sales/Project Manager-DP</asp:ListItem>
                            <asp:ListItem>SAP GTS</asp:ListItem>
                            <asp:ListItem>SAS Contract Position</asp:ListItem>
                            <asp:ListItem>Scheduler/Planner V-C</asp:ListItem>
                            <asp:ListItem>Science & Technology Job Captain - C/H</asp:ListItem>
                            <asp:ListItem>Senior Compensation Analyst</asp:ListItem>
                            <asp:ListItem>Senior Device Driver Engineer</asp:ListItem>
                            <asp:ListItem>Senior Embedded Software Engineer</asp:ListItem>
                            <asp:ListItem>Senior Firmware Engineer</asp:ListItem>
                            <asp:ListItem>Senior Game Engineer</asp:ListItem>
                            <asp:ListItem>Senior Interior Designer Manager</asp:ListItem>
                            <asp:ListItem>Senior Manager of IT – SCADA</asp:ListItem>
                            <asp:ListItem>Senior Manufacturing Engineer w/Machining</asp:ListItem>
                            <asp:ListItem>Senior Network Operations Engineer</asp:ListItem>
                            <asp:ListItem>Senior Platform Engineer</asp:ListItem>
                            <asp:ListItem>Senior Principal RF/MS IC Design Engineer</asp:ListItem>
                            <asp:ListItem>Senior Programmer/Analyst - ERP</asp:ListItem>
                            <asp:ListItem>Senior Project Architect</asp:ListItem>
                            <asp:ListItem>Senior Project Engineer- Transportation</asp:ListItem>
                            <asp:ListItem>Senior Software Engineer</asp:ListItem>
                            <asp:ListItem>Senior Software Engineer/Architect</asp:ListItem>
                            <asp:ListItem>Service Technician</asp:ListItem>
                            <asp:ListItem>Sheet Metal Assembly Mechanic</asp:ListItem>
                            <asp:ListItem>Shipping Clerk & Stock Clerk</asp:ListItem>
                            <asp:ListItem>Site Engineer</asp:ListItem>
                            <asp:ListItem>Site Support Technician - 28680</asp:ListItem>
                            <asp:ListItem>Site Support Technicians -28681</asp:ListItem>
                            <asp:ListItem>Site Support Technicians - 28676</asp:ListItem>
                            <asp:ListItem>Site Support Technicians - 28678</asp:ListItem>
                            <asp:ListItem>Site Support Technicians -28674</asp:ListItem>
                            <asp:ListItem>Site Support Technicians 28675</asp:ListItem>
                            <asp:ListItem>Software Developer</asp:ListItem>
                            <asp:ListItem>Software Developer-DOORS-HTML5-Javascript</asp:ListItem>
                            <asp:ListItem>Software Development Project Manager</asp:ListItem>
                            <asp:ListItem>Software Engineer</asp:ListItem>
                            <asp:ListItem>Software Engineer - 25039</asp:ListItem>
                            <asp:ListItem>Software Engineer OSS Applications</asp:ListItem>
                            <asp:ListItem>Software Engineer, Generalist</asp:ListItem>
                            <asp:ListItem>Software Engineer- JAVA SWING</asp:ListItem>
                            <asp:ListItem>Software Functional Test Engineer #3971420</asp:ListItem>
                            <asp:ListItem>Software QA Engineer #3393481</asp:ListItem>
                            <asp:ListItem>Software QA Engineer - White Box Testing 3347559</asp:ListItem>
                            <asp:ListItem>Software Safety Engineer</asp:ListItem>
                            <asp:ListItem>Software Specialist II - 28637</asp:ListItem>
                            <asp:ListItem>Software V&V Engineer</asp:ListItem>
                            <asp:ListItem>SolidWorks Designer</asp:ListItem>
                            <asp:ListItem>Solutions Analyst</asp:ListItem>
                            <asp:ListItem>SQL Server Database Administrator</asp:ListItem>
                            <asp:ListItem>Sr Electrical Power Engineer</asp:ListItem>
                            <asp:ListItem>Sr Product Engineer - HVAC</asp:ListItem>
                            <asp:ListItem>Sr repair Tech</asp:ListItem>
                            <asp:ListItem>Sr Systems Analyst – SCADA</asp:ListItem>
                            <asp:ListItem>Sr. Solutions Developer (BI)</asp:ListItem>
                            <asp:ListItem>Sr. .Software Engineer (.NET)</asp:ListItem>
                            <asp:ListItem>Sr. Buyer #3383022</asp:ListItem>
                            <asp:ListItem>Sr. CAD Analyst/Programmer</asp:ListItem>
                            <asp:ListItem>Sr. Electrical Engineer</asp:ListItem>
                            <asp:ListItem>Sr. Engineering Specialist Electrical</asp:ListItem>
                            <asp:ListItem>Sr. Global Die Engineer</asp:ListItem>
                            <asp:ListItem>Sr. HW Technician</asp:ListItem>
                            <asp:ListItem>Sr. Java Developers</asp:ListItem>
                            <asp:ListItem>Sr. Maintenance Technician</asp:ListItem>
                            <asp:ListItem>Sr. Manufacturing Project Engineer</asp:ListItem>
                            <asp:ListItem>Sr. Mechanical Engineer</asp:ListItem>
                            <asp:ListItem>Sr. Mechanical Engineer (Carlsbad) - D</asp:ListItem>
                            <asp:ListItem>Sr. Mechanical Engineer V</asp:ListItem>
                            <asp:ListItem>Sr. Mechanical Engineer-D (San Jose)</asp:ListItem>
                            <asp:ListItem>Sr. Planner</asp:ListItem>
                            <asp:ListItem>Sr. Powertrain Designer</asp:ListItem>
                            <asp:ListItem>Sr. Process Engineer-C/H</asp:ListItem>
                            <asp:ListItem>Sr. Process Engineer-D</asp:ListItem>
                            <asp:ListItem>Sr. Product Design Engineer</asp:ListItem>
                            <asp:ListItem>Sr. Product Development Engineer</asp:ListItem>
                            <asp:ListItem>Sr. Product Engineer – Engine Cooling</asp:ListItem>
                            <asp:ListItem>Sr. Proj Eng-Transp.- D</asp:ListItem>
                            <asp:ListItem>Sr. Quality Engineer/ Supervisor</asp:ListItem>
                            <asp:ListItem>Sr. R&D Engineer</asp:ListItem>
                            <asp:ListItem>Sr. RF Engineering Tech</asp:ListItem>
                            <asp:ListItem>Sr. SAP EC Consultant</asp:ListItem>
                            <asp:ListItem>Sr. Search Fullfilment Specialist #0872</asp:ListItem>
                            <asp:ListItem>Sr. Software Engineer #0855</asp:ListItem>
                            <asp:ListItem>Sr. Software Engineer #0959</asp:ListItem>
                            <asp:ListItem>Sr. Software Engineer #0960</asp:ListItem>
                            <asp:ListItem>Sr. Software Engineer C/C++</asp:ListItem>
                            <asp:ListItem>Sr. Software Engineers - Java</asp:ListItem>
                            <asp:ListItem>Sr. Software QA Engineer</asp:ListItem>
                            <asp:ListItem>Sr. Structural Project Mgr/Leader- Transport - D</asp:ListItem>
                            <asp:ListItem>Sr. Subcontracts Administrator/Manager</asp:ListItem>
                            <asp:ListItem>Sr. User Interface Designer</asp:ListItem>
                            <asp:ListItem>Sr./Pr. Electrical Engineer</asp:ListItem>
                            <asp:ListItem>Sr./Pr. Mechanical Engineer</asp:ListItem>
                            <asp:ListItem>Sr.Civil Dsn Eng.Supervisor-C-H</asp:ListItem>
                            <asp:ListItem>Staff Bluetooth Architect</asp:ListItem>
                            <asp:ListItem>Staff Engineer, Network Security #1836</asp:ListItem>
                            <asp:ListItem>Staffing Manager - Santa Ana</asp:ListItem>
                            <asp:ListItem>Storage Administrator Position - 28665</asp:ListItem>
                            <asp:ListItem>Structural Bridge Engineer – OKC</asp:ListItem>
                            <asp:ListItem>Structural Engineer</asp:ListItem>
                            <asp:ListItem>Structural Engineer - D</asp:ListItem>
                            <asp:ListItem>Structural Engineer III</asp:ListItem>
                            <asp:ListItem>Structural Engineers - C</asp:ListItem>
                            <asp:ListItem>Subcontract Administrator IV - C</asp:ListItem>
                            <asp:ListItem>Subdivision Engineer-C-H</asp:ListItem>
                            <asp:ListItem>Supervisor Electrical Engineer - D</asp:ListItem>
                            <asp:ListItem>Supervisor Equtiity Programs</asp:ListItem>
                            <asp:ListItem>Supplier Quality Engineer</asp:ListItem>
                            <asp:ListItem>Supply Chain</asp:ListItem>
                            <asp:ListItem>Survey Technician</asp:ListItem>
                            <asp:ListItem>SW Eng. - Database & Web Services</asp:ListItem>
                            <asp:ListItem>Systems & Integration Engineer - Propulsion - C</asp:ListItem>
                            <asp:ListItem>Systems Administrator IV - 28576</asp:ListItem>
                            <asp:ListItem>Systems Automation Engineer</asp:ListItem>
                            <asp:ListItem>Systems Engineer</asp:ListItem>
                            <asp:ListItem>Systems Engineer - 24940</asp:ListItem>
                            <asp:ListItem>Systems Engineer - 25308</asp:ListItem>
                            <asp:ListItem>Systems Engineer -24963</asp:ListItem>
                            <asp:ListItem>Systems Support Administrator</asp:ListItem>
                            <asp:ListItem>Team Center Developer -0133</asp:ListItem>
                            <asp:ListItem>Technical Analyst - 00132</asp:ListItem>
                            <asp:ListItem>Technical Manager</asp:ListItem>
                            <asp:ListItem>Technical Operations Engineer</asp:ListItem>
                            <asp:ListItem>Technical Project Manager SOA, RESTful web service</asp:ListItem>
                            <asp:ListItem>Technical Support Engineer - 25300</asp:ListItem>
                            <asp:ListItem>Technical Web Producer #0968</asp:ListItem>
                            <asp:ListItem>Technical Writer</asp:ListItem>
                            <asp:ListItem>Technician</asp:ListItem>
                            <asp:ListItem>Technology Manager - DP</asp:ListItem>
                            <asp:ListItem>Tooling Manager</asp:ListItem>
                            <asp:ListItem>Training Manager</asp:ListItem>
                            <asp:ListItem>Transportation Design Manager/Engineer</asp:ListItem>
                            <asp:ListItem>Transportation Service Leader</asp:ListItem>
                            <asp:ListItem>UGNX Designer</asp:ListItem>
                            <asp:ListItem>UI Developer</asp:ListItem>
                            <asp:ListItem>UI Front End Lead Engineer</asp:ListItem>
                            <asp:ListItem>User Experience Lead</asp:ListItem>
                            <asp:ListItem>UX Software Engineer</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 264px; height: 22px; text-align: left;">
                        <asp:CustomValidator ID="FieldValidator" runat="server" Display="Dynamic" ErrorMessage="&amp;nbsp;* Required" ForeColor="Red" OnServerValidate="FieldValidator_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right; height: 22px;">Education:&nbsp;</td>
                    <td style="width: 190px; text-align: left; height: 22px;">
                        <asp:DropDownList ID="DdEdu" Width="190px" runat="server">
                            <asp:ListItem>Choose</asp:ListItem>
                            <asp:ListItem Value="1">High School</asp:ListItem>
                            <asp:ListItem Value="2">Associate</asp:ListItem>
                            <asp:ListItem Value="3">Bachelors</asp:ListItem>
                            <asp:ListItem Value="4">Advanced Degree</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 264px; text-align: left; height: 22px;">
                        <asp:CustomValidator ID="EduValidator" runat="server" Display="Dynamic" ErrorMessage="&amp;nbsp;* Required" ForeColor="Red" OnServerValidate="EduValidator_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right;">Experience:&nbsp;</td>
                    <td style="width: 190px; text-align: left;">
                        <asp:DropDownList ID="DdExp" Width="190px" runat="server">
                            <asp:ListItem>Choose</asp:ListItem>
                            <asp:ListItem Value="0">None</asp:ListItem>
                            <asp:ListItem Value="1">1+ Years</asp:ListItem>
                            <asp:ListItem Value="2">2+ Years</asp:ListItem>
                            <asp:ListItem Value="3">3+ Years</asp:ListItem>
                            <asp:ListItem Value="4">4+ Years</asp:ListItem>
                            <asp:ListItem Value="5">5+ Years</asp:ListItem>
                            <asp:ListItem Value="6">6+ Years</asp:ListItem>
                            <asp:ListItem Value="7">7+ Years</asp:ListItem>
                            <asp:ListItem Value="8">8+ Years</asp:ListItem>
                            <asp:ListItem Value="9">9+ Years</asp:ListItem>
                            <asp:ListItem Value="9">10+ Years</asp:ListItem>
                            <asp:ListItem Value="11">11+ Years</asp:ListItem>
                            <asp:ListItem Value="12">12+ Years</asp:ListItem>
                            <asp:ListItem Value="13">13+ Years</asp:ListItem>
                            <asp:ListItem Value="14">14+ Years</asp:ListItem>
                            <asp:ListItem Value="15">15+ Years</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 264px; text-align: left;">
                        <asp:CustomValidator ID="ExpValidator" runat="server" Display="Dynamic" ErrorMessage="&amp;nbsp;* Required" ForeColor="Red" OnServerValidate="ExpValidator_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right;">Salary Range:&nbsp;</td>
                    <td style="width: 190px; text-align: left;">
                        <asp:DropDownList ID="DdSal" Width="190px" runat="server">
                            <asp:ListItem>Choose</asp:ListItem>
                            <asp:ListItem Value="1">$10,000+</asp:ListItem>
                            <asp:ListItem Value="2">$20,000+</asp:ListItem>
                            <asp:ListItem Value="3">$30,000+</asp:ListItem>
                            <asp:ListItem Value="4">$40,000+</asp:ListItem>
                            <asp:ListItem Value="5">$50,000+</asp:ListItem>
                            <asp:ListItem Value="6">$60,000+</asp:ListItem>
                            <asp:ListItem Value="7">$70,000+</asp:ListItem>
                            <asp:ListItem Value="8">$80,000+</asp:ListItem>
                            <asp:ListItem Value="9">$90,000+</asp:ListItem>
                            <asp:ListItem Value="10">$100,000+</asp:ListItem>
                            <asp:ListItem Value="11">$110,000+</asp:ListItem>
                            <asp:ListItem Value="12">$120,000+</asp:ListItem>
                            <asp:ListItem Value="13">$130,000+</asp:ListItem>
                            <asp:ListItem Value="14">$140,000+</asp:ListItem>
                            <asp:ListItem Value="15">$150,000+</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 264px; text-align: left;">
                        <asp:CustomValidator ID="SalValidator" runat="server" Display="Dynamic" ErrorMessage="&amp;nbsp;* Required" ForeColor="Red" OnServerValidate="SalValidator_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right;">ZIPCODE:&nbsp;</td>
                    <td style="width: 190px; text-align: left;">
                        <asp:TextBox ID="txtZip" runat="server" Width="190px"></asp:TextBox>
                    </td>
                    <td style="width: 264px; text-align: left;">
                        <asp:CustomValidator ID="ZipValidator" runat="server" Display="Dynamic" ErrorMessage="&amp;nbsp;* Invalid value" ForeColor="Red" OnServerValidate="ZipValidator_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right;">&nbsp;</td>
                    <td style="width: 190px; text-align: left;">&nbsp;</td>
                    <td style="width: 264px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right;">Looking for Work?</td>
                    <td style="width: 190px; text-align: left;">
                        &nbsp;<asp:RadioButton ID="RadioStatus1" runat="server" Text="Yes" GroupName="RadioStatus" />
                        <br />
                        &nbsp;<asp:RadioButton ID="RadioStatus0" runat="server" Text="No" GroupName="RadioStatus" />
                    </td>
                    <td style="width: 264px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 354px; text-align: right;">&nbsp;</td>
                    <td style="width: 190px">&nbsp;</td>
                    <td style="width: 264px">&nbsp;</td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width: 874px">
                        Resume</td>
                </tr>
                <tr>
                    <td style="width: 874px">
                        <asp:TextBox ID="txtResume" runat="server" Height="362px" TextMode="MultiLine" Width="813px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="BtnUpdate" Class="btn btn-primary" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                    </td>
                </tr>
            </table>
        
        </asp:Panel>
        </div>
</asp:Content>

