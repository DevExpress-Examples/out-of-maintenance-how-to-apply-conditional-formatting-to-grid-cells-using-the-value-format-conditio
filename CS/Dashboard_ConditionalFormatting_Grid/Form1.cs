using DevExpress.DashboardCommon;

namespace Grid_ValueCondition {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            Dashboard dashboard = new Dashboard(); dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridMeasureColumn extendedPrice = (GridMeasureColumn)grid.Columns[1];

            GridItemFormatRule lessThanRule = new GridItemFormatRule(extendedPrice);
            FormatConditionValue lessThanCondition = new FormatConditionValue();
            lessThanCondition.Condition = DashboardFormatCondition.LessOrEqual;
            lessThanCondition.Value1 = 100000;
            lessThanCondition.StyleSettings = 
                new AppearanceSettings(FormatConditionAppearanceType.FontRed);
            lessThanRule.Condition = lessThanCondition;

            GridItemFormatRule betweenRule = new GridItemFormatRule(extendedPrice);
            FormatConditionValue betweenCondition = new FormatConditionValue();
            betweenCondition.Condition = DashboardFormatCondition.Between;
            betweenCondition.Value1 = 100000;
            betweenCondition.Value2 = 200000;
            betweenCondition.StyleSettings = 
                new AppearanceSettings(FormatConditionAppearanceType.FontYellow);
            betweenRule.Condition = betweenCondition;

            GridItemFormatRule greaterThanRule = new GridItemFormatRule(extendedPrice);
            FormatConditionValue greaterThanCondition = new FormatConditionValue();
            greaterThanCondition.Condition = DashboardFormatCondition.GreaterOrEqual;
            greaterThanCondition.Value1 = 200000;
            greaterThanCondition.StyleSettings = 
                new AppearanceSettings(FormatConditionAppearanceType.FontGreen);
            greaterThanRule.Condition = greaterThanCondition;

            grid.FormatRules.AddRange(lessThanRule, betweenRule, greaterThanRule);
        }
    }
}
